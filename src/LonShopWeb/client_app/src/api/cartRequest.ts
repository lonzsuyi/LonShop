import { stringify } from 'qs'
import httpRequest from '../untils/httpRequest'
import CONSTANTS from '../globalConfig'

import { CartState, CartItem } from '../constants/cart'

export async function getOrCreateCart() {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: { id: '', cart: [] }, msg: '' })
    }

    const url = `${CONSTANTS.API.PREFIX}/basket/getorcreatebasket`
    return httpRequest.get(url).then((res: any) => {
        return res
    }).catch(() => {
        return {}
    })
}

export async function addGood(params: CartItem) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: '', msg: '' })
    }

    const url = `${CONSTANTS.API.PREFIX}/basket/additem`
    return httpRequest.post(url, {
        goodId: params.id,
        price: params.good.price,
        quantity: params.quantity
    }).then((res: any) => {
        return res
    }).catch(() => {
        return {}
    })
}

export async function updateGood(params: CartItem) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: '', msg: '' })
    }
}

export async function updateCart(params: CartState) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: '', msg: '' })
    }

    const url = `${CONSTANTS.API.PREFIX}/basket/updatebasket`
    let temp: any = {};
    params.cartItems.forEach((item: CartItem) => {
        temp[item.id] = item.quantity
    })

    return httpRequest.put(url, {
        id: params.id,
        quantities: temp
    }).then((res: any) => {
        return res
    }).catch(() => {
        return {}
    })
}

export async function delGood(params: CartItem) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: '', msg: '' })
    }

    const url = `${CONSTANTS.API.PREFIX}/basket/signin`
}

export async function cleanGood() {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: '', msg: '' })
    }

}

export async function delCart(chartId: number) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: '', msg: '' })
    }

    const url = `${CONSTANTS.API.PREFIX}/basket/deletebasket`
    return httpRequest.delete(url, {
        data: {
            id: chartId
        }
    }).then((res: any) => {
        return true
    }).catch(() => {
        return false
    })
}