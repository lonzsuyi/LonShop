import React from 'react'
import { Card, Row, Col, Button } from 'antd'

import { GoodState } from '../.././actions/constants/good'

import './stylesheets/GoodsWindow.scss'

interface GoodsWindowProps {
    goods: Array<GoodState>
    addCart: Function
    buyNow: Function
}

function GoodsWindow(props: GoodsWindowProps) {
    return (
        <div className="goodswindow-contaier">
            {
                props.goods.map((item: GoodState, index: number) => {
                    return (
                        <Card
                            key={index}
                            className="goodcard"
                            hoverable
                            cover={<img className="good-img" alt={item.name} src={item.picUrl} />}
                        >
                            <Row>
                                <Col className="name">{item.name}</Col>
                            </Row>
                            <Row className="price-panel" justify="center">
                                <Col className="price">{item.price}</Col>
                                <Col className="currency">{item.currency}</Col>
                            </Row>
                            <Row>
                                <Col>
                                    <Button className="btn" type="primary" onClick={() => { props.buyNow(item) }}>Buy Now</Button>
                                </Col>
                                <Col>
                                    <Button className="btn" type="primary" ghost onClick={() => { props.addCart(item) }}>Add Cart</Button>
                                </Col>
                            </Row>
                        </Card>
                    )
                })
            }
        </div>
    )
}

export default GoodsWindow