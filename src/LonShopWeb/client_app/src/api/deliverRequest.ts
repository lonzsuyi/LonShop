import { stringify } from 'qs'
import httpRequest from '../untils/httpRequest'
import CONSTANTS from '../globalConstants'

import deliverCost from '.././mock/deliverCost.json'

export async function getCost(goodsTotal: number) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve(deliverCost)
    }
}