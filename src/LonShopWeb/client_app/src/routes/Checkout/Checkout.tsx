import React, { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { Row, Col, Select, Button, message } from 'antd'

import GoodsList from '../.././component/GoodsList/GoodsList'

import { useAppSelector, useAppDispatch } from '../.././redux/hooks';;
import { selectAuth } from '../../redux/authSlice'
import { selectCart, updateCartASync, delCartASync } from '../../redux/cartSlice'
import * as deliverRequest from '../.././api/deliverRequest'
import * as countiesRateRequest from '../.././api/countiesRateRequest'
import * as checkoutRequest from '../.././api/checkoutRequest'
import { CartItem } from '../../constants/cart'
import { CurrencyState } from '../../constants/currency'
import { OrderParamsState } from '../../constants/order'
import globalConstants from '../../globalConfig'
import { plus, multiply } from '../.././untils/calculate'

import './stylesheets/Checkout.scss'

const { Option } = Select;

function Checkout(props: any) {

    // Get redux data
    const auth = useAppSelector(selectAuth)
    const cart = useAppSelector(selectCart)

    const dispatch = useAppDispatch();
    const navigate = useNavigate();
    const [cost, setCost] = useState(0.00)
    const [rateChoice, setRateChoice] = useState(0.0)
    const [currency, setCurrency] = useState("")
    const [currencyCode, setCurrencyCode] = useState("")
    const [countiesRate, setCountiesRate] = useState([])



    const goodsTotal = cart.cartItems.reduce((prev: any, curv: any) => {
        return multiply(plus(prev, multiply(curv.quantity, curv.good.price)), rateChoice)
    }, 0.0);

    // Http request method
    const getCountiesRate = async () => {
        const data: any = await countiesRateRequest.getCountiesRate();
        if (data.code === 200) {
            setCurrency(data.result[0].id)
            setCurrencyCode(data.result[0].code)
            setRateChoice(data.result[0].rate)
            setCountiesRate(data.result)
        } else {
            message.error('Get countires rate error, please retry')
        }
    }
    const getCost = async (goodsTotal: number) => {
        const data: any = await deliverRequest.getCost(goodsTotal);
        if (data.code === 200) {
            setCost(multiply(data.result, rateChoice));
        } else {
            message.error('Cost calculate error, please retry')
        }
    }

    // Handle method
    const delCartItem = async (params: CartItem) => {
        params.quantity = 0 // Clean quantity mean remove.
        const data: any = await dispatch(updateCartASync({
            id: cart.id,
            cartItems: cart.cartItems.map((item: CartItem) => {
                if (item.id === params.id) {
                    let temp = params
                    temp.quantity = 0  // Clean quantity mean remove.
                    return params
                } else {
                    return item
                }
            }),
            buyerId: cart.buyerId
        })).unwrap()

        if (data.code !== 200) {
            message.error('Delete good in error, please retry')
        }
    }
    const changeCartItem = async (quantity: number, params: CartItem) => {
        if (quantity <= 0) {
            return
        }

        const data: any = await dispatch(updateCartASync({
            id: cart.id,
            cartItems: cart.cartItems.map((item: CartItem) => {
                if (item.id === params.id) {
                    return { ...params, quantity: 0 }  // Change quantity
                } else {
                    return item
                }
            }),
            buyerId: cart.buyerId
        })).unwrap()

        if (data.code !== 200) {
            message.error('Change good in error, please retry')
        }
    }
    const currencyChange = (id: string) => {
        const choiseCurrent: any = countiesRate.find((item: CurrencyState) => {
            return item.id === parseInt(id);
        })
        setCurrencyCode(choiseCurrent.code)
        setRateChoice(choiseCurrent.rate)
        setCurrency(choiseCurrent.id)
    }
    const toCheckout = async () => {
        // Verify sign in and cart count
        if (!auth.token) {
            navigate(globalConstants.ROUTES.SIGNIN)
            return
        }
        if (cart.cartItems.length <= 0) {
            message.info('The cart is nll, please add good and retry')
            return
        }

        let params: OrderParamsState = {
            cartId: cart.id,
            currencyId: parseInt(currency)
        }

        const data: any = await checkoutRequest.checkout(params)
        if (data.code === 200) {
            // Success clean cart.
            await dispatch(delCartASync(cart.id));
            // dispatch(cartActions.cleanCart())
            navigate(globalConstants.ROUTES.THANKPAGE)
        } else {
            message.error('Checkout error,please retry')
        }
    }

    /**
     * hook
     */
    useEffect(() => {
        getCountiesRate()
    }, [])
    useEffect(() => {
        if (cart.cartItems.length > 0) {
            getCost(goodsTotal)
        }
    }, [goodsTotal])

    return (
        <div className="checkout-container">
            <GoodsList carts={cart.cartItems} delCartItem={delCartItem} changeCartItem={changeCartItem} />
            <Row className="total" justify="space-between" align="middle">
                <Col>
                    <Row>
                        <span className="pirce-lable">Goods Total :</span>
                        <span className="pirce">{`${goodsTotal.toFixed(2)} ${currencyCode}`}</span>
                    </Row>
                    <Row>
                        <span className="pirce-lable">Cost :</span>
                        <span className="pirce">{`${cost.toFixed(2)} ${currencyCode}`}</span>
                    </Row>
                    <Row>
                        <span className="pirce-lable">Total Amount Payable :</span>
                        <span className="pirce">{`${plus(goodsTotal, cost)?.toFixed(2)} ${currencyCode}`}</span>
                    </Row>
                </Col>
                <Col>
                    <Select className="countiesrage-select" value={currency} onChange={currencyChange}>
                        {
                            countiesRate.map((item: any, index: number) => {
                                return (
                                    <Option key={index} value={item.id}>{`${item.code} : * ${item.rate}`}</Option>
                                )
                            })
                        }
                    </Select>
                    <Button className="checkout-btn" type="primary" size="large" onClick={toCheckout}>
                        Checkout Now
                    </Button>
                </Col>
            </Row>
        </div>
    )
}

export default Checkout