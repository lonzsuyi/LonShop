import React from 'react'
import { useSelector } from 'react-redux'
import { Link } from 'react-router-dom'

import { Layout, Row, Col, Badge } from 'antd'
import { ShoppingCartOutlined } from '@ant-design/icons'
import globalConstants from '../.././globalConstants'

import './stylesheets/Header.scss'

const { Header } = Layout

function HeaderContainer() {

    // Get redux data
    const { authReducer, cartReducer } = useSelector((store: any) => ({
        authReducer: store.authReducer,
        cartReducer: store.cartReducer
    }))

    return (
        <Header className="header">
            <Row className="header-container" justify="space-between">
                <Col className="header-container-logo">
                    <h1 className="logo">
                        <Link to="/">LonShop</Link>
                    </h1>
                </Col>
                <Col className="header-right">
                    <Row justify="center" align="middle">
                        {
                            authReducer.token ? [
                                <Col key={0} className='user-info'>{authReducer.username}</Col>,
                                <Col key={1} className='cart'>
                                    <Link to={globalConstants.ROUTES.MYCART}>
                                        <Badge count={cartReducer.cart.reduce((prev: any, curv: any) => prev + curv.quantity, 0)}>
                                            <ShoppingCartOutlined className="cart-icon" />
                                        </Badge>
                                    </Link>
                                </Col>
                            ] : (<Link className="signin" to={globalConstants.ROUTES.SIGNIN}>Sign In</Link>)
                        }
                    </Row>
                </Col>
            </Row>
        </Header>
    )
}

export default HeaderContainer