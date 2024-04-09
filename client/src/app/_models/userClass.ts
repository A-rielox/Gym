import { DaysEnum } from '../_enums/day.enum';

export interface UserClass {
   classId: number;
   className: string;
   classInfo: ClassInfo[];
}

export interface ClassInfo {
   dayName: DaysEnum;
   hourName: number;
   sectorName: string;
}
