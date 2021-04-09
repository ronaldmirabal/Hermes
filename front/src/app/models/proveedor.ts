export interface Proveedor{
    id: number;
    nombre: string;
    telefono: string;
    Noidentificacion: string;
    direccion: string;
    estado: boolean;
    ididentificacionType: {id: number; nombre:string};
}