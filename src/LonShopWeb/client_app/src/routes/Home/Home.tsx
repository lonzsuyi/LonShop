import React, { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { message } from 'antd'

import Banner from '../../component/Banner/Banner'
import GoodsWindows from '../../component/GoodsWindow/GoodsWindow'

import { useAppSelector, useAppDispatch } from '../.././redux/hooks';
import { addCartItemASync } from '../../redux/cartSlice';
import { GoodState } from '../../constants/good'
import { selectAuth } from '../../redux/authSlice'
import { CartItem } from '../../constants/cart'
import * as goodRequest from '../.././api/goodsRequest'
import globalConstants from '../../globalConfig'

function Home() {

    // Get redux data
    const auth = useAppSelector(selectAuth)

    const dispatch = useAppDispatch();
    const navigate = useNavigate()
    const [goods, setGoods] = useState([]);

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
        if (!auth.token) {
            navigate(globalConstants.ROUTES.SIGNIN)
            return
        }

        addCartItem(params)
    }
    const buyNow = (params: GoodState) => {
        if (!auth.token) {
            navigate(globalConstants.ROUTES.SIGNIN)
            return
        }

        addCartItem(params)
        navigate(globalConstants.ROUTES.MYCART)
    }
    const addCartItem = async (params: GoodState) => {
        let cartParams: CartItem = {
            id: params.id,
            good: params,
            quantity: 1,
            status: true
        };
        await dispatch(addCartItemASync(cartParams))

        // const addCartItem = async () => {
        //     const data: any = await cartRequest.addGood(cartParams);
        //     if (data.code === 200) {
        //         // dispatch(cartActions.setCart({
        //         //     id: data.result.id,
        //         //     buyerId: data.result.buyerId,
        //         //     cart: data.result.items.map((item: CartItem) => {
        //         //         return item
        //         //     })
        //         // }))
        //         // dispatch(cartActions.addCart(cartParams))
        //     } else {
        //         message.error('Add good in error, please retry')
        //     }
        // }

        // addCartItem()
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