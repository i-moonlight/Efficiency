import { Months } from "./Months";

export interface Goal {
    ID: number;
    month: Months;
    Year: number;
    Value: number;
    StoreID?: number;
}

export type Goals = Array<Goal>;
