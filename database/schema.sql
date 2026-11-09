-- ==============================================================
-- Proje Yönetim Sistemi Veritabanı Şeması ve Saklı Yordamlar
-- Veritabanı: MySQL 8.x / MariaDB
-- ==============================================================

CREATE DATABASE IF NOT EXISTS `databaseproje` 
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;

USE `databaseproje`;

-- -------------------------------------------------------------
-- 1. Tablo Tanımları
-- -------------------------------------------------------------

-- Kullanıcılar Tablosu
CREATE TABLE IF NOT EXISTS `Kullanicilar` (
    `KullaniciID` INT AUTO_INCREMENT PRIMARY KEY,
    `KullaniciAdi` VARCHAR(50) NOT NULL UNIQUE,
    `Eposta` VARCHAR(100) NOT NULL UNIQUE,
    `Parola` VARCHAR(255) NOT NULL,
    `OlusturmaTarihi` TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Çalışanlar Tablosu
CREATE TABLE IF NOT EXISTS `Calisanlar` (
    `CalisanID` INT AUTO_INCREMENT PRIMARY KEY,
    `AdSoyad` VARCHAR(100) NOT NULL,
    `Pozisyon` VARCHAR(100) NOT NULL,
    `KayitTarihi` TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Projeler Tablosu
CREATE TABLE IF NOT EXISTS `Projeler` (
    `ProjeID` INT AUTO_INCREMENT PRIMARY KEY,
    `ProjeAdi` VARCHAR(150) NOT NULL,
    `BaslangicTarihi` DATE NOT NULL,
    `BitisTarihi` DATE NOT NULL,
    `KullaniciID` INT DEFAULT NULL,
    `OlusturmaTarihi` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT `fk_projeler_kullanici` FOREIGN KEY (`KullaniciID`) 
        REFERENCES `Kullanicilar` (`KullaniciID`) 
        ON DELETE SET NULL 
        ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- -------------------------------------------------------------
-- 2. Saklı Yordamlar (Stored Procedures)
-- -------------------------------------------------------------

-- Çalışanları Listele
DROP PROCEDURE IF EXISTS `CalisanlariListele`;
DELIMITER //
CREATE PROCEDURE `CalisanlariListele`()
BEGIN
    SELECT 
        `CalisanID`, 
        `AdSoyad`, 
        `Pozisyon`, 
        `KayitTarihi` 
    FROM `Calisanlar`
    ORDER BY `CalisanID` DESC;
END //
DELIMITER ;

-- Çalışan Ekle
DROP PROCEDURE IF EXISTS `CalisanEkle`;
DELIMITER //
CREATE PROCEDURE `CalisanEkle`(
    IN `AdSoyad` VARCHAR(100),
    IN `Pozisyon` VARCHAR(100)
)
BEGIN
    INSERT INTO `Calisanlar` (`AdSoyad`, `Pozisyon`)
    VALUES (`AdSoyad`, `Pozisyon`);
END //
DELIMITER ;

-- Çalışan Sil
DROP PROCEDURE IF EXISTS `CalisanSil`;
DELIMITER //
CREATE PROCEDURE `CalisanSil`(
    IN `p_CalisanID` INT
)
BEGIN
    DELETE FROM `Calisanlar` 
    WHERE `CalisanID` = `p_CalisanID`;
END //
DELIMITER ;

-- Çalışan Güncelle
DROP PROCEDURE IF EXISTS `CalisanGuncelle`;
DELIMITER //
CREATE PROCEDURE `CalisanGuncelle`(
    IN `p_CalisanID` INT,
    IN `p_AdSoyad` VARCHAR(100),
    IN `p_Pozisyon` VARCHAR(100)
)
BEGIN
    UPDATE `Calisanlar`
    SET 
        `AdSoyad` = `p_AdSoyad`,
        `Pozisyon` = `p_Pozisyon`
    WHERE `CalisanID` = `p_CalisanID`;
END //
DELIMITER ;

-- Projeleri Listele
DROP PROCEDURE IF EXISTS `ProjeleriListele`;
DELIMITER //
CREATE PROCEDURE `ProjeleriListele`()
BEGIN
    SELECT 
        p.`ProjeID`,
        p.`ProjeAdi`,
        p.`BaslangicTarihi`,
        p.`BitisTarihi`,
        COALESCE(k.`KullaniciAdi`, 'Atanmamış') AS `Yonetici`
    FROM `Projeler` p
    LEFT JOIN `Kullanicilar` k ON p.`KullaniciID` = k.`KullaniciID`
    ORDER BY p.`ProjeID` DESC;
END //
DELIMITER ;

-- Proje Ekle
DROP PROCEDURE IF EXISTS `ProjeEkle`;
DELIMITER //
CREATE PROCEDURE `ProjeEkle`(
    IN `ProjeAdi` VARCHAR(150),
    IN `BaslangicTarihi` DATE,
    IN `BitisTarihi` DATE,
    IN `KullaniciID` INT
)
BEGIN
    INSERT INTO `Projeler` (`ProjeAdi`, `BaslangicTarihi`, `BitisTarihi`, `KullaniciID`)
    VALUES (`ProjeAdi`, `BaslangicTarihi`, `BitisTarihi`, `KullaniciID`);
END //
DELIMITER ;

-- Proje Sil
DROP PROCEDURE IF EXISTS `ProjeSil`;
DELIMITER //
CREATE PROCEDURE `ProjeSil`(
    IN `p_ProjeID` INT
)
BEGIN
    DELETE FROM `Projeler` WHERE `ProjeID` = `p_ProjeID`;
END //
DELIMITER ;

-- Kullanıcı Var Mı Kontrolü (Tekillik doğrulama)
DROP PROCEDURE IF EXISTS `KullaniciVarMi`;
DELIMITER //
CREATE PROCEDURE `KullaniciVarMi`(
    IN `p_KullaniciAdi` VARCHAR(50),
    IN `p_Eposta` VARCHAR(100)
)
BEGIN
    SELECT COUNT(*) AS `KayitSayisi`
    FROM `Kullanicilar`
    WHERE `KullaniciAdi` = `p_KullaniciAdi` OR `Eposta` = `p_Eposta`;
END //
DELIMITER ;

-- Kullanıcı Ekle
DROP PROCEDURE IF EXISTS `KullaniciEkle`;
DELIMITER //
CREATE PROCEDURE `KullaniciEkle`(
    IN `p_KullaniciAdi` VARCHAR(50),
    IN `p_Eposta` VARCHAR(100),
    IN `p_Parola` VARCHAR(255)
)
BEGIN
    INSERT INTO `Kullanicilar` (`KullaniciAdi`, `Eposta`, `Parola`)
    VALUES (`p_KullaniciAdi`, `p_Eposta`, `p_Parola`);
END //
DELIMITER ;

-- Kullanıcıları Listele (Proje atama veya yönetim için)
DROP PROCEDURE IF EXISTS `KullanicilariListele`;
DELIMITER //
CREATE PROCEDURE `KullanicilariListele`()
BEGIN
    SELECT `KullaniciID`, `KullaniciAdi`, `Eposta`, `OlusturmaTarihi`
    FROM `Kullanicilar`
    ORDER BY `KullaniciID` ASC;
END //
DELIMITER ;

-- -------------------------------------------------------------
-- 3. Örnek Başlangıç Verileri (Seed Data)
-- -------------------------------------------------------------

-- admin kullanıcısı (parola: 123456 - SHA256: 8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92)
INSERT IGNORE INTO `Kullanicilar` (`KullaniciID`, `KullaniciAdi`, `Eposta`, `Parola`) VALUES
(1, 'admin', 'admin@yonetim.local', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92');

INSERT IGNORE INTO `Calisanlar` (`CalisanID`, `AdSoyad`, `Pozisyon`) VALUES
(1, 'Ahmet Yılmaz', 'Kıdemli Yazılım Mühendisi'),
(2, 'Ayşe Kaya', 'Proje Yöneticisi'),
(3, 'Mehmet Demir', 'Veritabanı Yöneticisi');

INSERT IGNORE INTO `Projeler` (`ProjeID`, `ProjeAdi`, `BaslangicTarihi`, `BitisTarihi`, `KullaniciID`) VALUES
(1, 'E-Ticaret Altyapı Modernizasyonu', '2025-01-01', '2025-06-30', 1),
(2, 'Mobil Saha Satış Entegrasyonu', '2025-03-15', '2025-09-15', 1);
