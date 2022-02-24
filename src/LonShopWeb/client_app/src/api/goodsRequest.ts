import { stringify } from 'qs'
import httpRequest from '../untils/httpRequest'
import CONSTANTS from '../globalConfig'

import goodsData from '../mock/goods.json'

// Get goods
export async function getGoods() {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve(goodsData)
    }

    const url = `${CONSTANTS.API.PREFIX}/good/getGoods`
    return httpRequest.get(url).then((res: any) => {
        return res.data
    }).catch(() => {
        return []
    })
}
