import { stringify } from 'qs'
import httpRequest from '.././untils/httpRequest'
import CONSTANTS from '../globalConfig'

import authData from '.././mock/auth.json'

// Sign in
export async function signIn(username: string, password: string) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve(authData)
    }

    const url = `${CONSTANTS.API.PREFIX}/auth/signin`
    return httpRequest.post(url, {
        username: username,
        password: password,
        rememberMe: false
    }).then((res: any) => {
        localStorage.setItem('LonShopToken', res.data.result.token)
        return res
    }).catch(() => {
        return []
    })
}
