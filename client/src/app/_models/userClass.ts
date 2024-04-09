export interface UserClass {
   classId: number;
   className: string;
   classInfo: ClassInfo[];
}

export interface ClassInfo {
   dayName: string;
   hourName: number;
   sectorName: string;
}
