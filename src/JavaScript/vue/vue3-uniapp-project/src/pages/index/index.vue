<template>
  <view class="content">
    <image class="logo" src="/static/logo.png" />
    <view class="text-area">
      <text class="title">{{ title }}</text>
    </view>
    <view class="pictures">
      <image
        v-for="picture in pictures"
        :key="picture.id"
        :src="picture.url"
        @click="onPreviewImage(picture.url)"
        class="picture"
      />
    </view>
  </view>
</template>

<script setup lang="ts">
import { ref } from "vue";

const title = ref("Hello uni-app test");
const pictures = ref([
  {
    id: "1",
    url: "/static/images/goods_preview_1.jpg",
  },
  {
    id: "2",
    url: "/static/images/goods_preview_2.jpg",
  },
  {
    id: "3",
    url: "/static/images/goods_preview_3.jpg",
  },
]);

const onPreviewImage = (url: string) => {
  console.log("onPreviewImage", url);
  uni.previewImage({
    urls: pictures.value.map((item) => item.url),
    current: url,
  });
};
</script>

<style>
.content {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}
.pictures {
  display: flex;
  flex-wrap: wrap;
  gap: 10px;
}
.picture {
  width: 100px;
  height: 100px;
  object-fit: cover;
  cursor: pointer;
}
</style>
