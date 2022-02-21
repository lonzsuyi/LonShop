import React from 'react'
import { Row, Col, InputNumber, Button, message } from 'antd'
import { MinusOutlined } from '@ant-design/icons'

import { multiply } from '../.././untils/calculate'
import { CartItem } from '../.././actions/constants/cart'

import './stylesheets/GoodsList.scss'

interface GoodsListProps {
    carts: Array<CartItem>
    delCartItem: Function
    changeCartItem: Function
}

function GoodsList(props: GoodsListProps) {
    return (
        <div className="goodslist-container">
            {
                props.carts.map((item: CartItem, index: number) => {
                    return (
                        <Row key={index} className="cart-item" justify="space-between" align="top">
                            <Col>
                                <Row>
                                    <Col>
                                        <Button className="remove-btn" danger shape="circle" icon={<MinusOutlined />} size="middle" onClick={() => { props.delCartItem(item) }} />
                                    </Col>
                                    <Col>
                                        <img className='good-pic' alt={item.good.name} src={item.good.picUrl} />
                                    </Col>
                                    <Col className="good-info">
                                        <Row className="name">{item.good.name}</Row>
                                        <Row className="intro">{item.good.intro}</Row>
                                    </Col>
                                </Row>
                            </Col>
                            <Col>
                                <span className="price">{`${item.good.price} ${item.good.currency}`} X </span>
                                <InputNumber className="quantity" value={item.quantity} min={1} onChange={(value) => { props.changeCartItem(value, item) }} />
                                <span className="price">{` = ${multiply(item.good.price, item.quantity)} ${item.good.currency}`}</span>
                            </Col>
                        </Row>
                    )
                })
            }
        </div>
    )
}

export default GoodsList