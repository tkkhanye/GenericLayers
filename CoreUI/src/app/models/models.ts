

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

export class VehicleModel{
    id:string;
    year:number;
    registrationNumber:string;
    vinNumber:string;
    startMileage:number;
    customerId:string;
    vehicleModelId:number;
    vehicleManufacturerId:number;
    vehicleMakeId: number;
    vehicleCategoryId:number;
    vehicleModel:LookupModel;
    vehicleMake:LookupModel;
    vehicleManufacturer:LookupModel;
    purchasePrice:number;
}

export class PolicyModel{
    id:string;
    startDate:Date;
    endDate:Date;
    startMileage:number;
    endMileage:number;
    contractDistance:number;
    productId:string;
    vehicleId:string;    
}

export class ProductModel{
    id:string;
    name:string;
    description:string;
    startDate:Date;
    endDate:Date;
    minimumMileage:number;
    maximumMileage:number;
    contractDistance:number;
    contractDuration:number;
    productType:number;
}