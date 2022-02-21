import React from 'react'
import { Layout, Row } from 'antd'

import './stylesheets/Footer.scss'

const { Footer } = Layout

function FooterContainer() {
    return (
        <Footer className="footer">
            <Row className="footer-container">
                Copyright &copy; LonShop 2022
            </Row>
        </Footer>
    )
}

export default FooterContainer