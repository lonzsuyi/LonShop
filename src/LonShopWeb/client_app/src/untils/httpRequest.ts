import axios from 'axios'

// axios instance
const httpRequest = axios.create()

// interceptors applies to every ajax call
httpRequest.interceptors.request.use(
    function (config: any) {
        config.headers['Authorization'] = `Bearer ${localStorage.getItem('LonShopToken')}`
        return config
    },
    function (err) {
        return Promise.reject(err)
    }
)

export default httpRequest