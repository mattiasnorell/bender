import { DeployEnviroments } from './DeployEnviroment';

export class ProjectItem {
    public id!: string;
    public name!: string;
    public lastDeployDateTime!: Date;
    public version!: string;
    public enviroments!: DeployEnviroments[];
}
