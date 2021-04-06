import { DetalleFactura } from './detalleFactura';
export interface Factura{
    idcliente: number;
    idTipoComprobante: number;
    detallefacturas: DetalleFactura[];
}