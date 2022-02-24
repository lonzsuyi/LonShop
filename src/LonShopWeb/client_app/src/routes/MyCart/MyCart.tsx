import React from 'react'
import { useNavigate } from 'react-router-dom'
import { Row, Col, Button, message } from 'antd'

import GoodsList from '../.././component/GoodsList/GoodsList'

import { useAppSelector, useAppDispatch } from '../.././redux/hooks';
import { selectCart, updateCartASync } from '../../redux/cartSlice';
import { selectAuth } from '../../redux/authSlice'
import { CartItem } from '../../constants/cart'
import { plus, multiply } from '../.././untils/calculate'
import globalConstants from '../../globalConfig'

import './stylesheets/MyCart.scss'

function MyCart(props: any) {

    // Get redux data
    const auth = useAppSelector(selectAuth)
    const cart = useAppSelector(selectCart)

    const dispatch = useAppDispatch();
    const navigate = useNavigate();

    // Handle method
    const delCartItem = async (params: CartItem) => {
        const data: any = await dispatch(updateCartASync({
            id: cart.id,
            cartItems: cart.cartItems.map((item: CartItem) => {
                if (item.id === params.id) {
                    let temp = params
                    return { ...params, quantity: 0 }  // Clean quantity mean remove.
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
                    return { ...params, quantity: quantity } // Change quantity
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
    const toCheckout = () => {
        // Verify sign in and cart count
        if (!auth.token) {
            navigate(globalConstants.ROUTES.SIGNIN)
            return
        }
        if (cart.cartItems.length <= 0) {
            message.info('The cart is nll, please add good and retry')
            return
        }

        navigate(globalConstants.ROUTES.CHECKOUT)
    }

    return (
        <div className="mycart-container">
            <GoodsList carts={cart.cartItems} delCartItem={delCartItem} changeCartItem={changeCartItem} />
            <Row className="cart-total" justify="space-between" align="middle">
                <Col className="pirce">
                    <span>Total:</span>
                    <span>{cart.cartItems.reduce((prev: any, curv: any) => {
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


