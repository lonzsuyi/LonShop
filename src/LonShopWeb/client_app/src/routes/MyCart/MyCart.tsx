import React from 'react'
import { useNavigate } from 'react-router-dom'
import { useSelector, useDispatch } from 'react-redux'
import { Row, Col, Button, message } from 'antd'

import GoodsList from '../.././component/GoodsList/GoodsList'

import globalConstants from '../.././globalConstants'
import { plus, multiply } from '../.././untils/calculate'
import { CartItem } from '../.././actions/constants/cart'
import * as cartActions from '../.././actions/cartActions'
import * as cartRequest from '../../api/cartRequest'

import './stylesheets/MyCart.scss'

function MyCart(props: any) {

    const dispatch = useDispatch()
    const navigate = useNavigate();

    // Get redux data
    const { authReducer, cartReducer } = useSelector((store: any) => ({
        authReducer: store.authReducer,
        cartReducer: store.cartReducer
    }))
    const { cart } = cartReducer

    // Handle method
    const delCartItem = async (params: CartItem) => {
        const data: any = await cartRequest.delGood(params);
        if (data.code === 200) {
            dispatch(cartActions.delCart(params))
        } else {
            message.error('Delete good in error, please retry')
        }
    }
    const changeCartItem = async (quantity: number, params: CartItem) => {
        if (quantity <= 0) {
            return
        }
        params.quantity = quantity // Change quantity
        const data: any = await cartRequest.updateGood(params);
        if (data.code === 200) {
            dispatch(cartActions.udpateCart(params))
        } else {
            message.error('Change good in error, please retry')
        }
    }
    const toCheckout = () => {
        // Verify sign in and cart count
        if (!authReducer.token) {
            navigate(globalConstants.ROUTES.SIGNIN)
            return
        }
        if (cart <= 0) {
            message.info('The cart is nll, please add good and retry')
            return
        }

        navigate(globalConstants.ROUTES.CHECKOUT)
    }

    return (
        <div className="mycart-container">
            <GoodsList carts={cart} delCartItem={delCartItem} changeCartItem={changeCartItem} />
            <Row className="cart-total" justify="space-between" align="middle">
                <Col className="pirce">
                    <span>Total:</span>
                    <span>{cart.reduce((prev: any, curv: any) => {
                        return plus(prev, multiply(curv.quantity, curv.good.price))
                    }, 0.0)} AUD</span>
                </Col>
                <Col>
                    <Button className="checkout-btn" type="primary" size="large" onClick={toCheckout}>
                        Checkout Now
                    </Button>
                </Col>
            </Row>
        </div>
    )
}

export default MyCart;


