
<template>
  <div>
    <md-table md-card>
      <md-table-toolbar>
        <h1 class="md-title">Projects</h1>
      </md-table-toolbar>

      <md-table-row>
        <md-table-head>ID</md-table-head>
        <md-table-head>Project</md-table-head>
        <md-table-head>Last deploy</md-table-head>
        <md-table-head>Version</md-table-head>
        <md-table-head>Actions</md-table-head>
      </md-table-row>

      <Project class="md-layout-item md-size-50" v-bind:projectItem="projectItem" v-bind:key="projectItem.id" v-for="projectItem in projects"></Project>
    </md-table>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import Project from './Project.vue';
import { ProjectItem } from './ProjectItem';
import { Settings } from './Settings';
import { DeployEnviroments } from './DeployEnviroment';
import { MdCard, MdTable } from 'vue-material/dist/components';
import axios, { AxiosResponse, AxiosAdapter, AxiosInstance } from 'axios';

Vue.use(MdCard);
Vue.use(MdTable);

@Component({
  components: {
    Project,
  },
})
export default class ProjectList extends Vue {
  public projects!: ProjectItem[];

  public mounted(): void {
    axios.get('http://localhost:5010/api/projects/getall').then((response: AxiosResponse) => {
      this.projects = response.data;
    });
  }

  private data() {
    return {
      projects: null,
    };
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
