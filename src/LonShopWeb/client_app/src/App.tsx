import React from 'react'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Layout, Row, Col } from 'antd'

import globalConstants from './globalConstants'

import HeaderContainer from './component/Header/Header'
import FooterContainer from './component/Footer/Footer'

// Route page
import LazyLoading from './component/LazyLoading/LazyLoading'
const Home = React.lazy(() => import('./routes/Home/Home'))
const SignIn = React.lazy(() => import('./routes/SignIn/SignIn'))
const MyCart = React.lazy(() => import('./routes/MyCart/MyCart'))
const MyOrder = React.lazy(() => import('./routes/MyOrder/MyOrder'))
const Checkout = React.lazy(() => import('./routes/Checkout/Checkout'))
const PayStatus = React.lazy(() => import('./routes/PayStatus/PayStatus'))
const ThankPage = React.lazy(() => import('./routes/ThankPage/ThankPage'))

const { Content } = Layout

function App(props: any) {
    return (
        <React.Fragment>
            <Layout>
                <Content className="content">
                    <Router>
                        <HeaderContainer />
                        <React.Suspense fallback={< LazyLoading />}>
                            <Routes>
                                <Route path={globalConstants.ROUTES.HOME} element={<Home />} />
                                <Route path={globalConstants.ROUTES.SIGNIN} element={<SignIn />} />
                                <Route path={globalConstants.ROUTES.MYCART} element={<MyCart />} />
                                <Route path={globalConstants.ROUTES.MYORDER} element={<MyOrder />} />
                                <Route path={globalConstants.ROUTES.CHECKOUT} element={<Checkout />} />
                                <Route path={globalConstants.ROUTES.PAYSTATUS} element={<PayStatus />} />
                                <Route path={globalConstants.ROUTES.THANKPAGE} element={<ThankPage />} />
                            </Routes>
                        </React.Suspense>
                        <FooterContainer />
                    </Router>
                </Content>
            </Layout>
        </React.Fragment>
    )
}

export default App;