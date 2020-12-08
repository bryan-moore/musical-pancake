export const SECOND = 1000;
export const HOUR = 24;

export function getZeroPad(n) {
    return (parseInt(n, 10) >= 10 ? '' : '0') + n
}