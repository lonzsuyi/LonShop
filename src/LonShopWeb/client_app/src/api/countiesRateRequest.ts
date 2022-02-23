import { stringify } from 'qs'
import httpRequest from '../untils/httpRequest'
import CONSTANTS from '../globalConstants'

import countiesRateData from '.././mock/countriesRate.json'

export async function getCountiesRate() {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve(countiesRateData)
    }

    const url = `${CONSTANTS.API.PREFIX}/currency/getcurrencies`
    return httpRequest.get(url).then((res: any) => {
        return res.data
    }).catch(() => {
        return []
    })
}