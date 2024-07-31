/**
 * add interceptors
 * request interceptor
 * file upload
 *
 * TODO
 * 1. 非http开头需拼接地址
 * 2。 请求超时
 * 3. 添加小程序端的请求头标识
 * 4. 添加token请求头
 */

import { useMemberStore } from '@/stores'

const baseURL = 'https://shopapi.vibeehome.cn'

// add interceptors
const httpInterceptors = {
  // request interceptor
  invoke(options: UniApp.RequestOptions) {
    // add baseURL
    if (!options.url.startsWith('http')) {
      options.url = baseURL + options.url
    }

    // add timeout
    options.timeout = 10000
    // add header
    options.header = {
      ...options.header,
      'source-client': 'mini-program',
    }
    // add toker
    const memberStore = useMemberStore()
    const token = memberStore.profile?.token
    if (token) {
      options.header.Authorization = 'Bearer ' + token
    }
    console.log('request options', options)
  },
}
uni.addInterceptor('request', httpInterceptors)
uni.addInterceptor('uploadFile', httpInterceptors)

/**
 * @param options uniapp.requestoptions
 * @returns Promise
 * 1. return promise object
 * 2. success
 *   1. resolve(response)
 *    2. add type support
 * 3. fail
 *  1. network error hint user
 *  2. 401 clear user profile and return login page
 *  3. other fail hint user accordding response data
 *
 */

interface Data<T> {
  code: string
  data: T
  message: string
}

export const http = <T>(options: UniApp.RequestOptions) => {
  return new Promise<Data<T>>((resolve, reject) => {
    uni.request({
      ...options,
      success(response) {
        if (response.statusCode >= 200 && response.statusCode < 300) {
          resolve(response.data as Data<T>)
        } else if (response.statusCode === 401) {
          const memberStore = useMemberStore()
          memberStore.clearProfile()
          uni.navigateTo({
            url: '/pages/login/login',
          })
          reject(response)
        } else {
          uni.showToast({
            title: (response.data as Data<T>)?.message || '请求错误',
            icon: 'none',
          })
          reject(response)
        }
      },
      fail(err) {
        uni.showToast({
          title: '网络错误',
          icon: 'none',
        })
      },
    })
  })
}
