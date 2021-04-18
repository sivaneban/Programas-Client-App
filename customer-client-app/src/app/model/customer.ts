export interface ICustomer {
    id: number,
    firstname: string,
    lastname: string,
    mobile: string,
    email: string,
    username: string,
    customerAddress: IAddress
}

export interface IAddress {
    id: number,
    addressFull: string,
    addressLine1: string,
    addressLine2: string,
    addressLine3: string,
    city: string,
    state: string,
    postcode: string,
    country: string
}