import { stringify } from 'qs'
import httpRequest from '../untils/httpRequest'
import CONSTANTS from '../globalConfig'

import { OrderParamsState } from '../constants/order'

export async function checkout(params: OrderParamsState) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: '', msg: '' })
    }

    const url = `${CONSTANTS.API.PREFIX}/order/createorder`
    return httpRequest.post(url, {
        basketId: params.cartId,
        currencyId: params.currencyId
    }).then((res: any) => {
        return res.data
    }).catch(() => {
        return {}
    })
}