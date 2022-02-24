import React from 'react'
import { Link } from 'react-router-dom'
import { Layout, Row, Col, Badge } from 'antd'
import { ShoppingCartOutlined } from '@ant-design/icons'

import { useAppSelector } from '../../redux/hooks'
import { selectAuth } from '../../redux/authSlice'
import { selectCart } from '../../redux/cartSlice'

import globalConstants from '../../globalConfig'

import './stylesheets/Header.scss'

const { Header } = Layout

function HeaderContainer() {

    // Get redux data
    const auth = useAppSelector(selectAuth)
    const cart = useAppSelector(selectCart)


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
                            auth.token ? [
                                <Col key={0} className='user-info'>{auth.username}</Col>,
                                <Col key={1} className='cart'>
                                    <Link to={globalConstants.ROUTES.MYCART}>
                                        <Badge count={cart.cartItems.reduce((prev: any, curv: any) => prev + curv.quantity, 0)}>
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