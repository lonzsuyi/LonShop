import { stringify } from 'qs'
import httpRequest from '../untils/httpRequest'
import CONSTANTS from '../globalConstants'

import goodsData from '../mock/goods.json'

// Get goods
export async function getGoods() {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve(goodsData)
    }

    const url = ``
}
