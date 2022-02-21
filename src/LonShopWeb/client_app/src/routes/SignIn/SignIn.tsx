import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux'
import { Row, Col, Input, Button, message } from 'antd'

import * as authAction from '../../actions/authActions'
import * as authRequest from '../../api/authRequest'
import globalConstants from '../.././globalConstants'

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
                    token: data.data.token,
                    username: data.data.username,
                    email: data.data.email,
                    expired: data.data.expired
                }))
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
        </div>
    )
}

export default SignIn;