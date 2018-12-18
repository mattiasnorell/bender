<template>
    <md-table-row>
      <md-table-cell>{{ projectItem.projectId }}</md-table-cell>
      <md-table-cell>{{ projectItem.projectName }}</md-table-cell>
      <md-table-cell>{{ projectItem.lastDeployAtUtc | moment("YYYY-MM-DD HH:mm") }}</md-table-cell>
      <md-table-cell>{{ projectItem.version }}</md-table-cell>
      <md-table-cell>
      
        <md-dialog-confirm :md-active.sync="confirmDeploy"
        md-title="Ok, just to make sure..."
        md-content="You are about to deploy <strong>Branch name</strong> to <strong>Environment</strong>"
        md-confirm-text="Deploy!"
        md-cancel-text="Cancel"
        @md-cancel="confirmDeploy = false"
        @md-confirm="onConfirmDeploy" />

        <md-dialog :md-active.sync="showDeployDialog">
            <md-dialog-title>Deploying!</md-dialog-title>

            <md-dialog-content>

              <span v-html="deployProgress"></span>
            </md-dialog-content>
            <md-dialog-actions>
              <md-button class="md-primary" @click="showDeployDialog = false">Close</md-button>
            </md-dialog-actions>
          </md-dialog>

          <md-menu md-direction="bottom-start">
            <md-button class="md-raised" md-menu-trigger :disabled="!projectItem.deployEnvironments || projectItem.deployEnvironments.length == 0">Deploy</md-button>

            <md-menu-content>
              <md-menu-item v-for="environment in projectItem.deployEnvironments" v-bind:key="environment.id" @click="deploy(projectItem.id, environment.id)">{{environment.name}}</md-menu-item>
            </md-menu-content>
          </md-menu>

          <md-button class="md-raised" disabled @click="test()" md-menu-trigger>Test</md-button>
          <md-button class="md-raised" @click="showHistory = true" md-menu-trigger>Logs</md-button>

          <md-dialog :md-active.sync="showHistory">
            <md-dialog-title>History</md-dialog-title>

            <md-dialog-content>
              <md-tabs md-dynamic-height>
                <md-tab md-label="1.0.3 (Current)">
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                </md-tab>

                <md-tab md-label="1.0.2">
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                </md-tab>

                <md-tab md-label="1.0.1">
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                  <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ullam mollitia dolorum dolores quae commodi impedit possimus qui, atque at voluptates cupiditate. Neque quae culpa suscipit praesentium inventore ducimus ipsa aut.</p>
                </md-tab>
              </md-tabs>
            </md-dialog-content>
            <md-dialog-actions>
              <md-button class="md-primary" @click="showHistory = false">Close</md-button>
            </md-dialog-actions>
          </md-dialog>
      </md-table-cell>
    </md-table-row>

   
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { MdButton, MdTable, MdTabs, MdMenu, MdList, MdDialog, MdDialogConfirm } from 'vue-material/dist/components';
import { ProjectItem } from './ProjectItem';
import veumoment from 'vue-moment';
import axios, { AxiosResponse, AxiosAdapter, AxiosInstance } from 'axios';

Vue.use(MdButton);
Vue.use(MdTable);
Vue.use(MdMenu);
Vue.use(MdList);
Vue.use(MdTabs);
Vue.use(MdDialogConfirm);
Vue.use(veumoment);
Vue.use(MdDialog);

@Component
export default class Project extends Vue {
  @Prop() private projectItem!: ProjectItem;

  private confirmDeploy: boolean = false;
  private showDeployDialog: boolean = false;
  private deployProgress: string = '';

  private data() {
    return {
      showHistory: false,
      confirmDeploy: this.confirmDeploy,
      showDeployDialog: this.showDeployDialog,
      deployProgress: this.deployProgress,
    };
  }

  private deploy(projectId: number, environmentId: number) {
    this.confirmDeploy = true;
  }

  private test(): void {
    alert('test');
  }

  private onConfirmDeploy(): void {
    this.confirmDeploy = false;
    this.showDeployDialog = true;
    const config = { projectId: 1, environmentId: 4 };
    axios.post('/api/projects/deploy', config).then((response: AxiosResponse) => {
      this.deployProgress = response.data;
    });
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

.md-list{
  background-color: #fff;
}
.md-menu-content-container{
  background-color: #fff;
}
.md-dialog{
  background-color: #fff;
}

.md-menu{
  margin-top: 6px;
}

</style>
