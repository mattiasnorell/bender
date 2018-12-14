<template>
  <md-table-row>
    <md-table-cell>{{ projectItem.id }}</md-table-cell>
    <md-table-cell>{{ projectItem.name }}</md-table-cell>
    <md-table-cell>{{ projectItem.lastDeployDateTime | moment("YYYY-MM-DD HH:mm") }}</md-table-cell>
    <md-table-cell>{{ projectItem.version }}</md-table-cell>
    <md-table-cell>
      <md-button class="md-raised" @click="deploy(enviroment.id)" md-menu-trigger>Deploy</md-button>
      <md-button class="md-raised" @click="deploy(enviroment.id)" md-menu-trigger>Test</md-button>
      <md-button class="md-raised" @click="deploy(enviroment.id)" md-menu-trigger>Logs</md-button>
    </md-table-cell>
  </md-table-row>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { MdButton, MdTable, MdMenu, MdList } from 'vue-material/dist/components';
import { ProjectItem } from './ProjectItem';
import veumoment from 'vue-moment';

Vue.use(MdButton);
Vue.use(MdTable);
Vue.use(MdMenu);
Vue.use(MdList);
Vue.use(veumoment);

@Component
export default class Project extends Vue {
  @Prop() private projectItem!: ProjectItem;

  private deploy(enviroment: string) {
    alert(enviroment);
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
