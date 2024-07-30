<script setup lang="ts">
import { onLaunch, onShow, onHide } from "@dcloudio/uni-app";
onLaunch(() => {
  console.log("App Launchtest");
});
onShow(() => {
  console.log("App Show dd test");
});
onHide(() => {
  console.log("App Hide");
});
</script>
<style></style>
