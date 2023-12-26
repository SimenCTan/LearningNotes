export const generateId = ()=>{
    let time = new Date();
    return time.getMilliseconds();
}
