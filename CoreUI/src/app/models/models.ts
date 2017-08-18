

export class AddressModel{
    line1:string;
    line2:string;
    line3:string;
    city:string;
    postalCode:number;
}

export class UserModel{
    firstName: string;
    lastName: string;
    userName: string
    email: string;
    password:string;
    establishmentType:number;
}

export class DealerModel{
    code: string;
    name: string;
    physicalAddress: AddressModel;
    postalAddress: AddressModel;
}

export class LookupModel{
    id: number;
    name: string;
    description: string;
    code: string;    
}

export class PropertyModel{
    id: string;
    numberOfBedrooms: number;
    physicalAddress: AddressModel;
    postalAddress: AddressModel;
}