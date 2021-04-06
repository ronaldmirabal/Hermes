import { Identificacion } from './identificacion';
export interface Cliente {
       id: number;
       nombre: string;
       telefono: string;
       identificacion: string;
       direccion: string;
       estado: boolean;
       ididentificacionType: {id: number; nombre:string};
}