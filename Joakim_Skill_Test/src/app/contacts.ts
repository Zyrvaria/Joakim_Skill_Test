import Contacts from '../assets/contacts.json';

//creating an interface for the contact so that it is easier to access the contents of whatever I get back from my queries
export interface Contact {
  ID: number;
  InfoID: number;
  Info: {
    ID: number;
    DefaultEmailID: number;
    DefaultPhoneID: number;
    InvoiceAddressID: number;
    Name: string;
    DefaultPhone: {
      ID: number;
      BusinessRelationID: number;
      CountryCode: string;
      Description: string;
      Number: string;
      Type: string;
    };
    DefaultEmail: {
      ID: number;
      BusinessRelationID: number;
      Deleted: boolean;
      Description: string;
      EmailAddress: string;
    };
    InvoiceAddress: {
      ID: number;
      BusinessRelationID: number;
      AddressLine1: string;
      AddressLine2: string;
      AddressLine3: string;
      City: string;
      Country: string;
      CountryCode: string;
      PostalCode: string;
      Region: string;
    };
  };
  Comment: string;
}
export const contacts = Contacts;
