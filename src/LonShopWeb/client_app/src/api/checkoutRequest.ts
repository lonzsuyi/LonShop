import { stringify } from 'qs'
import httpRequest from '../untils/httpRequest'
import CONSTANTS from '../globalConstants'

import { OrderParamsState } from '../actions/constants/order'

export async function checkout(params: OrderParamsState) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve({ code: 200, data: '', msg: '' })
    }
}