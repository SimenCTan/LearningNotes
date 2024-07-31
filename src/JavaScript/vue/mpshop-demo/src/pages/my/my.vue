<script setup lang="ts">
import { useMemberStore } from '@/stores';
import { http } from '@/utils/http.ts';

const memberStore = useMemberStore()
// test interceptor
const getData = async () => {
  const res = await http<string[]>({
    method: 'GET',
    url: '/home/banner',
    header: {},
  })
  console.log('res', res)
}
</script>

<template>
  <view class="my">
    <view>会员信息：{{ memberStore.profile }}</view>
    <button
      @tap="
        memberStore.setProfile({
          nickname: '黑马先锋',
          token: '12345',
        })
      "
      size="mini"
      plain
      type="primary"
    >
      保存用户信息
    </button>
    <button @tap="memberStore.clearProfile()" size="mini" plain type="warn">清理用户信息</button>
    <button @tap="getData()" size="mini">测试拦截器</button>
  </view>
</template>

<style lang="scss">
//
</style>
