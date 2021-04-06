
export interface Articulo{
    id: number;
    codigo: string;
    nombre: string;
    precio: number;
    costo: number;
    itbis: number;
    descripcion: string;
    tipo: string;
    estado: boolean;
    categoria: {id: number; nombre:string};
    stock: number;
}