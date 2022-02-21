import { stringify } from 'qs'
import httpRequest from '../untils/httpRequest'
import CONSTANTS from '../globalConstants'

import { CartItem } from '.././actions/constants/cart'

export async function addGood(params: CartItem) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: '', msg: '' })
    }
}

export async function updateGood(params: CartItem) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: '', msg: '' })
    }
}

export async function delGood(params: CartItem) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: '', msg: '' })
    }
}

export async function cleanGood() {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: '', msg: '' })
    }
}