-- MySQL dump 10.13  Distrib 8.0.15, for macos10.14 (x86_64)
--
-- Host: localhost    Database: larry_david
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20210106214455_Initial','2.2.6-servicing-10079');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Episodes`
--

DROP TABLE IF EXISTS `Episodes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Episodes` (
  `EpisodeId` int(11) NOT NULL AUTO_INCREMENT,
  `Show` longtext,
  `SeasonEpisode` longtext,
  PRIMARY KEY (`EpisodeId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Episodes`
--

LOCK TABLES `Episodes` WRITE;
/*!40000 ALTER TABLE `Episodes` DISABLE KEYS */;
INSERT INTO `Episodes` VALUES (2,NULL,NULL),(3,'Seinfeld','S02E04'),(4,'Curb Your Enthusiasm','S02E22');
/*!40000 ALTER TABLE `Episodes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EpisodeTheme`
--

DROP TABLE IF EXISTS `EpisodeTheme`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `EpisodeTheme` (
  `EpisodeThemeId` int(11) NOT NULL AUTO_INCREMENT,
  `EpisodeId` int(11) NOT NULL,
  `ThemeId` int(11) NOT NULL,
  PRIMARY KEY (`EpisodeThemeId`),
  KEY `IX_EpisodeTheme_EpisodeId` (`EpisodeId`),
  KEY `IX_EpisodeTheme_ThemeId` (`ThemeId`),
  CONSTRAINT `FK_EpisodeTheme_Episodes_EpisodeId` FOREIGN KEY (`EpisodeId`) REFERENCES `episodes` (`EpisodeId`) ON DELETE CASCADE,
  CONSTRAINT `FK_EpisodeTheme_Themes_ThemeId` FOREIGN KEY (`ThemeId`) REFERENCES `themes` (`ThemeId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EpisodeTheme`
--

LOCK TABLES `EpisodeTheme` WRITE;
/*!40000 ALTER TABLE `EpisodeTheme` DISABLE KEYS */;
INSERT INTO `EpisodeTheme` VALUES (3,2,1),(4,3,3),(5,3,1),(7,2,3),(8,3,5),(9,4,1),(10,4,3);
/*!40000 ALTER TABLE `EpisodeTheme` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Themes`
--

DROP TABLE IF EXISTS `Themes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Themes` (
  `ThemeId` int(11) NOT NULL AUTO_INCREMENT,
  `Joke` longtext,
  PRIMARY KEY (`ThemeId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Themes`
--

LOCK TABLES `Themes` WRITE;
/*!40000 ALTER TABLE `Themes` DISABLE KEYS */;
INSERT INTO `Themes` VALUES (1,'Puffy Shirts'),(3,'Larry in a Cape'),(5,'Elaine\'s Dancing');
/*!40000 ALTER TABLE `Themes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-01-07 14:01:22
