#[derive(Debug, Copy, Clone)]
pub struct Point(pub u32);

#[allow(unused)]
impl Point {
    pub fn from_xy(x: u16, y: u16) -> Point {
        Point(((y as u32) << 8) + ((x as u32 + 1 - (y as u32 & 1)) >> 1))
    }
    pub fn as_xy(&self) -> (u16, u16) {
        let num = self.0 >> 8;
        ((((self.0 & 255) << 1) + (num & 1)) as u16, num as u16)
    }
    pub fn from_point_code(zone_id: u16, point_id: u8) -> Point {
        Point(
            ((zone_id as u32 & 1023 & 15) << 4)
                + (point_id as u32 & 15)
                + ((((zone_id as u32 & 1023) >> 4 << 4) + (point_id as u32 >> 4)) << 8),
        )
    }
    pub fn as_point_code(&self) -> (u16, u8) {
        let num1 = self.0 & 255;
        let num2 = self.0 >> 8;
        (
            ((num2 >> 4 << 4) + (num1 >> 4)) as u16,
            (((num2 & 15) << 4) + (num1 & 15)) as u8,
        )
    }
}
