import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux'
import { Row, Col, Input, Button, message } from 'antd'

import * as authAction from '../../actions/authActions'
import * as authRequest from '../.././api/authRequest'
import * as cartAction from '../.././actions/cartActions'
import * as cartRequest from '../.././api/cartRequest'
import { CartItem } from '../.././actions/constants/cart';
import { GoodState } from '../../actions/constants/good';

import './stylesheets/SignIn.scss'



function SignIn(props: any) {

    const dispatch = useDispatch()
    const navigate = useNavigate();
    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')

    const SignIn = () => {

        // Verify field
        if (!username) {
            message.info('Pleas input username')
            return
        }
        if (!password) {
            message.info('Pleas input password')
            return
        }

        // Http request
        const signIn = async () => {
            const data: any = await authRequest.signIn(username, password)
            if (data.code === 200) {
                dispatch(authAction.setAuth({
                    token: data.result.token,
                    username: data.result.username,
                    email: data.result.email,
                    expired: data.result.expired
                }))

                console.log('success')

                // Init Cart
                const cartData: any = await cartRequest.getOrCreateCart()
                if (cartData.code == 200) {
                    dispatch(cartAction.setCart({
                        id: cartData.result.id,
                        cart: cartData.result.items.map((item: CartItem) => {
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
                        buyerId: cartData.result.buyerId
                    }))
                }

                navigate(-1)
            } else {
                message.error('Sign in error, please retry')
            }
        }

        signIn()
    }

    return (
        <div className="signin-container">
            <Row justify="center">
                <Col className=""><h2>Sign In</h2></Col>
            </Row>
            <Row justify="center">
                <Row>
                    <Col><Input placeholder="username" value={username} onChange={(e) => { setUsername(e.target.value) }} /></Col>
                </Row>
                <Row>
                    <Col><Input placeholder="password" type="password" value={password} onChange={(e) => { setPassword(e.target.value) }} /></Col>
                </Row>
            </Row>
            <Row className="btn" justify="center">
                <Col>
                    <Button type="primary" onClick={SignIn}>Sign In</Button>
                </Col>
            </Row>
            <Row className="btn" justify="center">
                Test Account: userName:user1@test.com,password:Pwd@13579
            </Row>
        </div>
    )
}

export default SignIn;