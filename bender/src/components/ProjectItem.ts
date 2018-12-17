import { DeployEnviroments } from './DeployEnviroment';

export class ProjectItem {
    public id!: string;
    public name!: string;
    public lastDeployAtUtc!: Date;
    public version!: string;
    public enviroments!: DeployEnviroments[];
}
