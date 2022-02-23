import React, { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { useSelector, useDispatch } from 'react-redux'
import { Row, Col, Select, Button, message } from 'antd'

import GoodsList from '../.././component/GoodsList/GoodsList'

import globalConstants from '../.././globalConstants'
import { plus, multiply } from '../.././untils/calculate'
import { CartItem } from '../.././actions/constants/cart'
import { CurrencyState } from '../.././actions/constants/currency'
import { OrderParamsState } from '../.././actions/constants/order'
import * as cartActions from '../.././actions/cartActions'
import * as cartRequest from '../.././api/cartRequest'
import * as deliverRequest from '../.././api/deliverRequest'
import * as countiesRateRequest from '../.././api/countiesRateRequest'
import * as checkoutRequest from '../.././api/checkoutRequest'

import './stylesheets/Checkout.scss'

const { Option } = Select;

function Checkout(props: any) {

    const dispatch = useDispatch()
    const navigate = useNavigate();
    const [cost, setCost] = useState(0.00)
    const [rateChoice, setRateChoice] = useState(0.0)
    const [currency, setCurrency] = useState("")
    const [countiesRate, setCountiesRate] = useState([])

    // Get redux data
    const { authReducer, cartReducer } = useSelector((store: any) => ({
        authReducer: store.authReducer,
        cartReducer: store.cartReducer
    }))
    const { id, cart, buyerId } = cartReducer
    const goodsTotal = cart.reduce((prev: any, curv: any) => {
        return multiply(plus(prev, multiply(curv.quantity, curv.good.price)), rateChoice)
    }, 0.0);

    // Http request method
    const getCountiesRate = async () => {
        const data: any = await countiesRateRequest.getCountiesRate();
        if (data.code === 200) {
            setCurrency(data.result[0].id)
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
        params.quantity = 0
        const data: any = await cartRequest.updateCart({
            id: id,
            cart: cart.map((item: CartItem) => {
                if (item.id === params.id) {
                    return params
                } else {
                    return item
                }
            }),
            buyerId: buyerId
        })
        if (data.code === 200) {
            setCart(data)
        } else {
            message.error('Delete good in error, please retry')
        }
    }
    const changeCartItem = async (quantity: number, params: CartItem) => {
        if (quantity <= 0) {
            return
        }
        params.quantity = quantity // Change quantity
        const data: any = await cartRequest.updateCart({
            id: id,
            cart: cart.map((item: CartItem) => {
                if (item.id === params.id) {
                    return params
                } else {
                    return item
                }
            }),
            buyerId: buyerId
        })
        if (data.code === 200) {
            setCart(data)
        } else {
            message.error('Change good in error, please retry')
        }
    }
    const setCart = (data: any) => {
        dispatch(cartActions.setCart({
            id: data.result.id,
            cart: data.result.items.map((item: CartItem) => {
                return {
                    id: item.id,
                    good: {
                        id: item.good.id,
                        name: item.good.name,
                        picUrl: item.good.picUrl,
                        intro: item.good.intro,
                        price: item.good.price,
                        currency: item.good.currency
                    },
                    quantity: item.quantity,
                    status: true
                }
            }),
            buyerId: data.result.buyerId
        }))
    }
    const currencyChange = (id: string) => {
        const choiseCurrent: any = countiesRate.find((item: CurrencyState) => {
            return item.id === parseInt(id);
        })
        setRateChoice(choiseCurrent.rate)
        setCurrency(choiseCurrent.id)
    }
    const toCheckout = async () => {
        // Verify sign in and cart count
        if (!authReducer.token) {
            navigate(globalConstants.ROUTES.SIGNIN)
            return
        }
        if (cart <= 0) {
            message.info('The cart is nll, please add good and retry')
            return
        }

        let params: OrderParamsState = {
            cartId: id,
            currencyId: parseInt(currency)
        }

        const data: any = await checkoutRequest.checkout(params)
        if (data.code === 200) {
            // Success clean cart.
            await cartRequest.delCart(id);
            await cartRequest.cleanGood();
            dispatch(cartActions.cleanCart())
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
        if (cart.length > 0) {
            getCost(goodsTotal)
        }
    }, [goodsTotal])

    return (
        <div className="checkout-container">
            <GoodsList carts={cart} delCartItem={delCartItem} changeCartItem={changeCartItem} />
            <Row className="total" justify="space-between" align="middle">
                <Col>
                    <Row>
                        <span className="pirce-lable">Goods Total :</span>
                        <span className="pirce">{`${goodsTotal.toFixed(2)} ${currency}`}</span>
                    </Row>
                    <Row>
                        <span className="pirce-lable">Cost :</span>
                        <span className="pirce">{`${cost.toFixed(2)} ${currency}`}</span>
                    </Row>
                    <Row>
                        <span className="pirce-lable">Total Amount Payable :</span>
                        <span className="pirce">{`${plus(goodsTotal, cost)?.toFixed(2)} ${currency}`}</span>
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