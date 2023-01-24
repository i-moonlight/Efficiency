import { LogUserDTO } from "src/app/Data/DTO/UserDTO";
import { PostUserDTO, PutUserDTO } from "./../../Data/DTO/UserDTO";
import { User, Users } from "src/app/Models/User";
import { IService } from "./IService";
import { Observable } from "rxjs";

export interface IEmployeeService extends IService {
    Get(id: number): Observable<User>;
    GetAll(skip: number, take: number): Observable<Users>;
    Delete(id: number): Observable<User>;
    Post(userDTO: PostUserDTO): Observable<User>;
    Put(userDTO: PutUserDTO): Observable<User>;
    LogIn(userDTO: LogUserDTO): Observable<any>;
    SignUp(userDTO: LogUserDTO): Observable<any>;
}
