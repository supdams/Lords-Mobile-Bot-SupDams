use std::any::TypeId;
use std::io::{Error, ErrorKind, Read, Result, Write};

use crate::Connection;

pub type VarInt = i32;
pub type VarLong = i64;
pub trait ByteBufRead {
    fn read_bool(&mut self) -> Result<bool>;
    fn read_u8(&mut self) -> Result<u8>;
    fn read_u16(&mut self) -> Result<u16>;
    fn read_u32(&mut self) -> Result<u32>;
    fn read_u64(&mut self) -> Result<u64>;
    fn read_u128(&mut self) -> Result<u128>;
    fn read_i8(&mut self) -> Result<i8>;
    fn read_i16(&mut self) -> Result<i16>;
    fn read_i32(&mut self) -> Result<i32>;
    fn read_i64(&mut self) -> Result<i64>;
    fn read_i128(&mut self) -> Result<i128>;
    fn read_f32(&mut self) -> Result<f32>;
    fn read_f64(&mut self) -> Result<f64>;
    fn read_varint(&mut self) -> Result<VarInt>;
    fn read_varlong(&mut self) -> Result<VarLong>;
    fn read_string(&mut self, length: usize) -> Result<String>;
    fn read_t<T: 'static>(&mut self) -> Result<T>;
}

pub trait ByteBufWrite {
    fn write_bool(&mut self, item: bool) -> Result<()>;
    fn write_u8(&mut self, item: u8) -> Result<()>;
    fn write_u16(&mut self, item: u16) -> Result<()>;
    fn write_u32(&mut self, item: u32) -> Result<()>;
    fn write_u64(&mut self, item: u64) -> Result<()>;
    fn write_u128(&mut self, item: u128) -> Result<()>;
    fn write_i8(&mut self, item: i8) -> Result<()>;
    fn write_i16(&mut self, item: i16) -> Result<()>;
    fn write_i32(&mut self, item: i32) -> Result<()>;
    fn write_i64(&mut self, item: i64) -> Result<()>;
    fn write_i128(&mut self, item: i128) -> Result<()>;
    fn write_f32(&mut self, item: f32) -> Result<()>;
    fn write_f64(&mut self, item: f64) -> Result<()>;
    fn write_varint(&mut self, item: VarInt) -> Result<()>;
    fn write_varlong(&mut self, item: VarLong) -> Result<()>;
    fn write_string(&mut self, item: &str, length: usize) -> Result<()>;
    fn write_t<T: 'static>(&mut self, item: T) -> Result<()>;
    fn write_seq_id(&mut self, connection: &mut Connection) -> Result<()>;
    fn write_guest_seq_id(&mut self, connection: &mut Connection) -> Result<()>;
}

impl<U> ByteBufRead for U
where
    U: Read,
{
    fn read_bool(&mut self) -> Result<bool> {
        match self.read_u8()? {
            0 => Ok(false),
            1 => Ok(true),
            _ => Err(Error::new(ErrorKind::InvalidData, "Invalid bool byte")),
        }
    }

    fn read_u8(&mut self) -> std::io::Result<u8> {
        let mut buf = [0; 1];
        let read = self.read(&mut buf)?;
        if read != 1 {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Cannot read, stream ended",
            ))
        } else {
            Ok(u8::from_le_bytes(buf))
        }
    }

    fn read_u16(&mut self) -> Result<u16> {
        let mut buf = [0; 2];
        let read = self.read(&mut buf)?;
        if read != 2 {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Cannot read, stream ended",
            ))
        } else {
            Ok(u16::from_le_bytes(buf))
        }
    }

    fn read_u32(&mut self) -> Result<u32> {
        let mut buf = [0; 4];
        let read = self.read(&mut buf)?;
        if read != 4 {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Cannot read, stream ended",
            ))
        } else {
            Ok(u32::from_le_bytes(buf))
        }
    }

    fn read_u64(&mut self) -> Result<u64> {
        let mut buf = [0; 8];
        let read = self.read(&mut buf)?;
        if read != 8 {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Cannot read, stream ended",
            ))
        } else {
            Ok(u64::from_le_bytes(buf))
        }
    }

    fn read_u128(&mut self) -> Result<u128> {
        let mut buf = [0; 16];
        let read = self.read(&mut buf)?;
        if read != 16 {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Cannot read, stream ended",
            ))
        } else {
            Ok(u128::from_le_bytes(buf))
        }
    }

    fn read_i8(&mut self) -> std::io::Result<i8> {
        let mut buf = [0; 1];
        let read = self.read(&mut buf)?;
        if read != 1 {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Cannot read, stream ended",
            ))
        } else {
            Ok(i8::from_le_bytes(buf))
        }
    }

    fn read_i16(&mut self) -> Result<i16> {
        let mut buf = [0; 2];
        let read = self.read(&mut buf)?;
        if read != 2 {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Cannot read, stream ended",
            ))
        } else {
            Ok(i16::from_le_bytes(buf))
        }
    }

    fn read_i32(&mut self) -> Result<i32> {
        let mut buf = [0; 4];
        let read = self.read(&mut buf)?;
        if read != 4 {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Cannot read, stream ended",
            ))
        } else {
            Ok(i32::from_le_bytes(buf))
        }
    }

    fn read_i64(&mut self) -> Result<i64> {
        let mut buf = [0; 8];
        let read = self.read(&mut buf)?;
        if read != 8 {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Cannot read, stream ended",
            ))
        } else {
            Ok(i64::from_le_bytes(buf))
        }
    }

    fn read_i128(&mut self) -> Result<i128> {
        let mut buf = [0; 16];
        let read = self.read(&mut buf)?;
        if read != 16 {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Cannot read, stream ended",
            ))
        } else {
            Ok(i128::from_le_bytes(buf))
        }
    }

    fn read_f32(&mut self) -> Result<f32> {
        let mut buf = [0; 4];
        let read = self.read(&mut buf)?;
        if read != 4 {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Cannot read, stream ended",
            ))
        } else {
            Ok(f32::from_le_bytes(buf))
        }
    }

    fn read_f64(&mut self) -> Result<f64> {
        let mut buf = [0; 8];
        let read = self.read(&mut buf)?;
        if read != 8 {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Cannot read, stream ended",
            ))
        } else {
            Ok(f64::from_le_bytes(buf))
        }
    }

    fn read_varint(&mut self) -> Result<VarInt> {
        let mut num_read = 0;
        let mut result: i32 = 0;
        let mut read = 0b10000000;
        while read & 0b10000000 != 0 {
            read = self.read_u8()?;
            let value = read & 0b01111111;
            result |= (value as VarInt) << (7 * num_read as VarInt);

            num_read += 1;
            if num_read > 5 {
                return Err(Error::new(ErrorKind::InvalidData, "VarInt too big"));
            }
        }
        Ok(result)
    }

    fn read_varlong(&mut self) -> Result<VarLong> {
        let mut num_read = 0;
        let mut result: i64 = 0;
        let mut read = 0b10000000;
        while read & 0b10000000 != 0 {
            read = self.read_u8()?;
            let value = read & 0b01111111;
            result |= (value as VarLong) << (7 * num_read as VarLong);

            num_read += 1;
            if num_read > 10 {
                return Err(Error::new(ErrorKind::InvalidData, "VarLong too big"));
            }
        }
        Ok(result)
    }

    fn read_string(&mut self, length: usize) -> Result<String> {
        let mut buf = vec![0; length];
        self.read_exact(&mut buf)?;
        if let Some(null) = buf.iter().position(|a| *a == 0x00) {
            buf.truncate(null);
        }
        let result = String::from_utf8(buf);
        if let Ok(result) = result {
            Ok(result)
        } else {
            Err(Error::new(
                ErrorKind::InvalidData,
                "Invalid UTF-8: ".to_string() + &result.unwrap_err().to_string(),
            ))
        }
    }

    fn read_t<T: 'static>(&mut self) -> Result<T> {
        let type_id = TypeId::of::<T>();

        if type_id == TypeId::of::<u8>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_u8()?) })
        } else if type_id == TypeId::of::<u16>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_u16()?) })
        } else if type_id == TypeId::of::<u32>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_u32()?) })
        } else if type_id == TypeId::of::<u64>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_u64()?) })
        } else if type_id == TypeId::of::<u128>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_u128()?) })
        } else if type_id == TypeId::of::<i8>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_i8()?) })
        } else if type_id == TypeId::of::<i16>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_i16()?) })
        } else if type_id == TypeId::of::<i32>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_i32()?) })
        } else if type_id == TypeId::of::<i64>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_i64()?) })
        } else if type_id == TypeId::of::<i128>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_i128()?) })
        } else if type_id == TypeId::of::<f32>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_f32()?) })
        } else if type_id == TypeId::of::<f64>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_f64()?) })
        } else if type_id == TypeId::of::<bool>() {
            Ok(unsafe { std::mem::transmute_copy(&self.read_bool()?) })
        } else {
            Err(Error::new(ErrorKind::NotFound, "Unknown type."))
        }
    }
}

impl<U> ByteBufWrite for U
where
    U: Write,
{
    fn write_bool(&mut self, item: bool) -> Result<()> {
        self.write_u8(if item { 1 } else { 0 })
    }

    fn write_u8(&mut self, item: u8) -> Result<()> {
        if let Err(err) = self.write(&item.to_le_bytes()) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_u16(&mut self, item: u16) -> Result<()> {
        if let Err(err) = self.write(&item.to_le_bytes()) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_u32(&mut self, item: u32) -> Result<()> {
        if let Err(err) = self.write(&item.to_le_bytes()) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_u64(&mut self, item: u64) -> Result<()> {
        if let Err(err) = self.write(&item.to_le_bytes()) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_u128(&mut self, item: u128) -> Result<()> {
        if let Err(err) = self.write(&item.to_le_bytes()) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_i8(&mut self, item: i8) -> Result<()> {
        if let Err(err) = self.write(&item.to_le_bytes()) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_i16(&mut self, item: i16) -> Result<()> {
        if let Err(err) = self.write(&item.to_le_bytes()) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_i32(&mut self, item: i32) -> Result<()> {
        if let Err(err) = self.write(&item.to_le_bytes()) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_i64(&mut self, item: i64) -> Result<()> {
        if let Err(err) = self.write(&item.to_le_bytes()) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_i128(&mut self, item: i128) -> Result<()> {
        if let Err(err) = self.write(&item.to_le_bytes()) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_f32(&mut self, item: f32) -> Result<()> {
        if let Err(err) = self.write(&item.to_le_bytes()) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_f64(&mut self, item: f64) -> Result<()> {
        if let Err(err) = self.write(&item.to_le_bytes()) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_varint(&mut self, mut item: i32) -> Result<()> {
        let mut bytes = vec![];
        loop {
            let mut b = (item & 0b01111111) as u8;
            item = ((item as u32) >> 7) as i32;
            if item != 0 {
                b |= 0b10000000;
            }
            bytes.push(b);
            if item == 0 {
                break;
            }
        }
        if let Err(err) = self.write(&bytes) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_varlong(&mut self, mut item: i64) -> Result<()> {
        let mut bytes = vec![];
        loop {
            let mut b = (item & 0b01111111) as u8;
            item = ((item as u64) >> 7) as i64;
            if item != 0 {
                b |= 0b10000000;
            }
            bytes.push(b);
            if item == 0 {
                break;
            }
        }
        if let Err(err) = self.write(&bytes) {
            Err(err)
        } else {
            Ok(())
        }
    }

    fn write_string(&mut self, item: &str, length: usize) -> Result<()> {
        let bytes = item.as_bytes();
        self.write_all(bytes)?;
        self.write_all(&vec![0; length - bytes.len()])?;
        Ok(())
    }

    fn write_t<T: 'static>(&mut self, item: T) -> Result<()> {
        let type_id = TypeId::of::<T>();

        if type_id == TypeId::of::<u8>() {
            self.write_u8(unsafe { std::mem::transmute_copy(&item) })
        } else if type_id == TypeId::of::<u16>() {
            self.write_u16(unsafe { std::mem::transmute_copy(&item) })
        } else if type_id == TypeId::of::<u32>() {
            self.write_u32(unsafe { std::mem::transmute_copy(&item) })
        } else if type_id == TypeId::of::<u64>() {
            self.write_u64(unsafe { std::mem::transmute_copy(&item) })
        } else if type_id == TypeId::of::<u128>() {
            self.write_u128(unsafe { std::mem::transmute_copy(&item) })
        } else if type_id == TypeId::of::<i8>() {
            self.write_i8(unsafe { std::mem::transmute_copy(&item) })
        } else if type_id == TypeId::of::<i16>() {
            self.write_i16(unsafe { std::mem::transmute_copy(&item) })
        } else if type_id == TypeId::of::<i32>() {
            self.write_i32(unsafe { std::mem::transmute_copy(&item) })
        } else if type_id == TypeId::of::<i64>() {
            self.write_i64(unsafe { std::mem::transmute_copy(&item) })
        } else if type_id == TypeId::of::<i128>() {
            self.write_i128(unsafe { std::mem::transmute_copy(&item) })
        } else if type_id == TypeId::of::<f32>() {
            self.write_f32(unsafe { std::mem::transmute_copy(&item) })
        } else if type_id == TypeId::of::<f64>() {
            self.write_f64(unsafe { std::mem::transmute_copy(&item) })
        } else {
            Err(Error::new(
                ErrorKind::NotFound,
                "Unknown type. Supported types are: [u8, u16, u32, u64, u128]",
            ))
        }
    }

    fn write_seq_id(&mut self, connection: &mut Connection) -> Result<()> {
        connection.seq_id += 1;
        self.write_u32(connection.seq_id)?;
        Ok(())
    }

    fn write_guest_seq_id(&mut self, connection: &mut Connection) -> Result<()> {
        connection.guest_seq_id += 1;
        self.write_u32(connection.guest_seq_id)?;
        Ok(())
    }
}

#[cfg(test)]
mod tests {
    mod read_tests {
        use std::io::{Cursor, Read};

        use crate::packet::ByteBufRead;

        #[test]
        fn test_u8() {
            assert_eq!(create_read().read_u8().unwrap(), 1);
        }

        #[test]
        fn test_u16() {
            assert_eq!(create_read().read_u16().unwrap(), 1 * 256 + 2);
        }

        #[test]
        fn test_u32() {
            assert_eq!(
                create_read().read_u32().unwrap(),
                1 * 256 * 256 * 256 + 2 * 256 * 256 + 3 * 256 + 4
            );
        }

        #[test]
        fn test_u64() {
            assert_eq!(
                create_read().read_u64().unwrap(),
                1 * 256 * 256 * 256 * 256 * 256 * 256 * 256
                    + 2 * 256 * 256 * 256 * 256 * 256 * 256
                    + 3 * 256 * 256 * 256 * 256 * 256
                    + 4 * 256 * 256 * 256 * 256
                    + 5 * 256 * 256 * 256
                    + 6 * 256 * 256
                    + 7 * 256
                    + 8
            );
        }

        #[test]
        fn test_u128() {
            // too many * 256
        }

        #[test]
        fn test_i8() {
            assert_eq!(create_read().read_i8().unwrap(), 1);
        }

        #[test]
        fn test_i16() {
            assert_eq!(create_read().read_i16().unwrap(), 1 * 256 + 2);
        }

        #[test]
        fn test_i32() {
            assert_eq!(
                create_read().read_i32().unwrap(),
                1 * 256 * 256 * 256 + 2 * 256 * 256 + 3 * 256 + 4
            );
        }

        #[test]
        fn test_i64() {
            assert_eq!(
                create_read().read_i64().unwrap(),
                1 * 256 * 256 * 256 * 256 * 256 * 256 * 256
                    + 2 * 256 * 256 * 256 * 256 * 256 * 256
                    + 3 * 256 * 256 * 256 * 256 * 256
                    + 4 * 256 * 256 * 256 * 256
                    + 5 * 256 * 256 * 256
                    + 6 * 256 * 256
                    + 7 * 256
                    + 8
            );
        }

        #[test]
        fn test_f32() {
            assert_eq!(
                create_read().read_f32().unwrap(),
                0.000000000000000000000000000000000000023879393
            );
        }

        #[test]
        fn test_f64() {
            assert_eq!(create_read().read_f64().unwrap(), 0.000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000820788039913184);
        }

        #[test]
        fn test_varint() {
            assert_eq!(Box::new(Cursor::new(vec!(0))).read_varint().unwrap(), 0);
            assert_eq!(Box::new(Cursor::new(vec!(1))).read_varint().unwrap(), 1);
            assert_eq!(
                Box::new(Cursor::new(vec!(128, 1))).read_varint().unwrap(),
                128
            );
            assert_eq!(
                Box::new(Cursor::new(vec!(255, 1))).read_varint().unwrap(),
                255
            );
            assert_eq!(
                Box::new(Cursor::new(vec!(255, 255, 127)))
                    .read_varint()
                    .unwrap(),
                2097151
            );
            assert_eq!(
                Box::new(Cursor::new(vec!(255, 255, 255, 255, 7)))
                    .read_varint()
                    .unwrap(),
                2147483647
            );
            assert_eq!(
                Box::new(Cursor::new(vec!(255, 255, 255, 255, 15)))
                    .read_varint()
                    .unwrap(),
                -1
            );
            assert_eq!(
                Box::new(Cursor::new(vec!(128, 128, 128, 128, 8)))
                    .read_varint()
                    .unwrap(),
                -2147483648
            );
        }

        #[test]
        fn test_varlong() {
            assert_eq!(
                Box::new(Cursor::new(vec!(255, 255, 127)))
                    .read_varlong()
                    .unwrap(),
                2097151
            );
            assert_eq!(
                Box::new(Cursor::new(vec!(255, 255, 255, 255, 7)))
                    .read_varlong()
                    .unwrap(),
                2147483647
            );
            assert_eq!(
                Box::new(Cursor::new(vec!(
                    255, 255, 255, 255, 255, 255, 255, 255, 127
                )))
                .read_varlong()
                .unwrap(),
                9223372036854775807
            );
            assert_eq!(
                Box::new(Cursor::new(vec!(
                    255, 255, 255, 255, 255, 255, 255, 255, 255, 1
                )))
                .read_varlong()
                .unwrap(),
                -1
            );
            assert_eq!(
                Box::new(Cursor::new(vec!(255, 255, 255, 255, 7)))
                    .read_varlong()
                    .unwrap(),
                2147483647
            );
        }

        #[test]
        fn test_chained() {
            let mut read = create_read();
            assert_eq!(read.read_i8().unwrap(), 1);
            assert_eq!(read.read_u16().unwrap(), 2 * 256 + 3);
            assert_eq!(read.read_u8().unwrap(), 4);
        }

        #[test]
        fn test_generic() {
            assert_eq!(create_read().read_t::<u8>().unwrap(), 1);
            assert_eq!(create_read().read_t::<u16>().unwrap(), 1 * 256 + 2);
        }

        fn create_read() -> Box<dyn Read> {
            Box::new(Cursor::new(vec![
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,
            ]))
        }
    }

    mod write_tests {
        use std::io::Cursor;

        use crate::packet::ByteBufWrite;

        #[test]
        fn test_u8() {
            let mut buf = create_write();
            buf.write_u8(1).unwrap();
            assert_eq!(buf.into_inner(), vec!(1));
        }

        #[test]
        fn test_u16() {
            let mut buf = create_write();
            buf.write_u16(1 * 256 + 2).unwrap();
            assert_eq!(buf.into_inner(), vec!(1, 2));
        }

        #[test]
        fn test_i16() {
            let mut buf = create_write();
            buf.write_i16(1 * 256 + 2).unwrap();
            assert_eq!(buf.into_inner(), vec!(1, 2));
        }

        #[test]
        fn test_f32() {
            let mut buf = create_write();
            buf.write_f32(0.000000000000000000000000000000000000023879393)
                .unwrap();
            assert_eq!(buf.into_inner(), vec!(1, 2, 3, 4));
        }

        #[test]
        fn test_varint() {
            let mut buf = create_write();
            buf.write_varint(2097151).unwrap();
            assert_eq!(buf.into_inner(), vec!(255, 255, 127));
            let mut buf = create_write();
            buf.write_varint(-1).unwrap();
            assert_eq!(buf.into_inner(), vec!(255, 255, 255, 255, 15));
        }

        #[test]
        fn test_chained() {
            let mut buf = create_write();
            buf.write_u8(5).unwrap();
            buf.write_u16(4 * 256 + 3).unwrap();
            buf.write_i8(2).unwrap();
            assert_eq!(buf.into_inner(), vec!(5, 4, 3, 2))
        }

        #[test]
        fn test_generic() {
            let mut buf = create_write();
            buf.write_t::<u16>(1 * 256 + 2).unwrap();
            assert_eq!(buf.into_inner(), vec!(1, 2));
        }

        // TODO more tests for all types, read+write tests

        fn create_write() -> Cursor<Vec<u8>> {
            Cursor::new(Vec::new())
        }
    }
}
