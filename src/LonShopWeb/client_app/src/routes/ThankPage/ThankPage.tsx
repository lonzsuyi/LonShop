import React from 'react'
import { useNavigate } from 'react-router-dom'
import { Result, Button } from 'antd';

import globalConstants from '../.././globalConstants'

import './stylesheets/ThankPage.scss'

function ThankPage(props: any) {

    const navigate = useNavigate();

    const toHome = () => {
        navigate(globalConstants.ROUTES.HOME)
    }

    return (
        <div className="thankpage-container">
            <Result
                status="success"
                title="Thank you"
                extra={[
                    <Button type="primary" key="console" onClick={toHome}>
                        Back to home
                    </Button>
                ]}
            />
        </div>
    )
}

export default ThankPage