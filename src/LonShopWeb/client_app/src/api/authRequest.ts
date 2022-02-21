import { stringify } from 'qs'
import httpRequest from '.././untils/httpRequest'
import CONSTANTS from '.././globalConstants'

import authData from '.././mock/auth.json'

// Sign in
export async function signIn(username: string, password: string) {
    if (CONSTANTS.API.MOCK) {
        return Promise.resolve(authData)
    }

    const url = ``
}
