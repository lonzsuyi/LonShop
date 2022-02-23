import React, { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { useSelector, useDispatch } from 'react-redux'
import { message } from 'antd'

import Banner from '../../component/Banner/Banner'
import GoodsWindows from '../../component/GoodsWindow/GoodsWindow'

import globalConstants from '../.././globalConstants'
import { GoodState } from '../.././actions/constants/good'
import { CartItem } from '../.././actions/constants/cart'
import * as cartActions from '../.././actions/cartActions'
import * as cartRequest from '../../api/cartRequest'
import * as goodRequest from '../.././api/goodsRequest'

function Home(props: any) {

    const dispatch = useDispatch()
    const navigate = useNavigate()
    const [goods, setGoods] = useState([]);

    // Get redux data
    const { authReducer } = useSelector((store: any) => ({
        authReducer: store.authReducer
    }))

    const getGoods = async () => {
        const data: any = await goodRequest.getGoods()
        if (data.code === 200) {
            setGoods(data.result)
        } else {
            message.error('Get goods data error, please retry')
        }
    }

    // Button method
    const addCart = (params: GoodState) => {
        if (!authReducer.token) {
            navigate(globalConstants.ROUTES.SIGNIN)
            return
        }

        addCartItem(params)
    }
    const buyNow = (params: GoodState) => {
        if (!authReducer.token) {
            navigate(globalConstants.ROUTES.SIGNIN)
            return
        }

        addCartItem(params)
        navigate(globalConstants.ROUTES.MYCART)
    }
    const addCartItem = (params: GoodState) => {
        let cartParams: CartItem = {
            id: params.id,
            good: params,
            quantity: 1,
            status: true
        };
        const addCartItem = async () => {
            const data: any = await cartRequest.addGood(cartParams);
            if (data.code === 200) {
                dispatch(cartActions.setCart({
                    id: data.result.id,
                    buyerId: data.result.buyerId,
                    cart: data.result.items.map((item: CartItem) => {
                        return item
                    })
                }))
                // dispatch(cartActions.addCart(cartParams))
            } else {
                message.error('Add good in error, please retry')
            }
        }

        addCartItem()
    }

    /**
     * hook
     */
    useEffect(() => {
        getGoods()
    }, [])

    return (
        <div className="home-container">
            <Banner />
            {/* <div className='category-filter'></div> */}
            <GoodsWindows goods={goods} addCart={addCart} buyNow={buyNow} />
        </div>
    )
}

export default Home