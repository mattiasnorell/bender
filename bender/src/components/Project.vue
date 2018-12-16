<template>
    <md-table-row>
      <md-table-cell>{{ projectItem.id }}</md-table-cell>
      <md-table-cell>{{ projectItem.name }}</md-table-cell>
      <md-table-cell>{{ projectItem.lastDeployDateTime | moment("YYYY-MM-DD HH:mm") }}</md-table-cell>
      <md-table-cell>{{ projectItem.version }}</md-table-cell>
      <md-table-cell>
        <md-dialog-confirm
      :md-active.sync="confirmDeploy"
      md-title="Ok, just to make sure..."
      md-content="You are about to deploy <strong>Branch name</strong> to <strong>Environment</strong>"
      md-confirm-text="Deploy!"
      md-cancel-text="Cancel"
      @md-cancel="confirmDeploy = false"
      @md-confirm="onConfirmDeploy" />

        <md-menu md-direction="bottom-start">
          <md-button class="md-raised" md-menu-trigger>Deploy</md-button>

          <md-menu-content>
            <md-menu-item v-for="enviroment in projectItem.enviroments" v-bind:key="enviroment.id" @click="deploy(enviroment.id)">{{enviroment.name}}</md-menu-item>
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

  private data() {
    return {
      showHistory: false,
      confirmDeploy: this.confirmDeploy,
    };
  }

  private deploy(enviroment: string) {
    this.confirmDeploy = true;
  }

  private test(): void {
    alert('test');
  }

  private onConfirmDeploy(): void {
    this.confirmDeploy = false;
    axios.get('http://localhost:5010/api/projects/deploy?id=feedbag-master').then((response: AxiosResponse) => {
      alert(response.data);
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
