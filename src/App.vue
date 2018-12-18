<template>
  <div>
   
    <md-content>
       <div class="md-layout">
          <div class="md-layout-item md-size-100">
            <ProjectList></ProjectList>
          </div>
        </div>
    </md-content>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import ProjectList from './components/ProjectList.vue';
import { MdContent } from 'vue-material/dist/components';

Vue.use(MdContent);

@Component({
  components: {
    ProjectList,
  },
})
export default class App extends Vue {}
</script>

<style lang="scss">
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
