import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { Row, Col, Input, Button, message } from 'antd'

import { useAppDispatch } from '../../redux/hooks';
import { signInASync } from '../../redux/authSlice'
import { getandCreateCartItemASync } from '../../redux/cartSlice'

import './stylesheets/SignIn.scss'

function SignIn(props: any) {

    const dispatch = useAppDispatch();
    const navigate = useNavigate();
    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')

    const SignIn = async () => {

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
        const data: any = await dispatch(signInASync({ username: username, password: password })).unwrap();
        if (data.code === 200) {
            await dispatch(getandCreateCartItemASync()).unwrap();
            navigate(-1)
        }
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