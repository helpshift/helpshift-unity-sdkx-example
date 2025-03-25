#import "HSDebug.h"

// HSDebug.mm
extern "C" {
    void HsPurge() {
        // Delete all data from data container.
        NSMutableArray<NSURL *> *urls = [[NSMutableArray alloc] initWithCapacity:0];
        [urls addObjectsFromArray:[[NSFileManager defaultManager] URLsForDirectory:NSLibraryDirectory inDomains:NSUserDomainMask]];
        [urls addObjectsFromArray:[[NSFileManager defaultManager] URLsForDirectory:NSDocumentDirectory inDomains:NSUserDomainMask]];
        for(NSURL *url in urls)
        {
            for(NSURL *file in [[NSFileManager defaultManager] contentsOfDirectoryAtURL:url includingPropertiesForKeys:nil options:NSDirectoryEnumerationSkipsSubdirectoryDescendants error:nil])
            {
                BOOL success = [[NSFileManager defaultManager] removeItemAtURL:file error:nil];
                if(!success) {
                    NSLog(@"Could not delete file at path:%@",[file absoluteString]);
                }
            }
        }

        // Delete all data from keychain.
        BOOL (^deleteAllKeysForSecClass)(CFTypeRef) = ^BOOL (CFTypeRef secClass) {
            id dict = @{ (__bridge id) kSecClass: (__bridge id) secClass };
            OSStatus result = SecItemDelete((__bridge CFDictionaryRef) dict);
            return result == noErr || result == errSecItemNotFound;
        };
        deleteAllKeysForSecClass(kSecClassInternetPassword);
        deleteAllKeysForSecClass(kSecClassGenericPassword);
        deleteAllKeysForSecClass(kSecClassCertificate);
        deleteAllKeysForSecClass(kSecClassKey);
        deleteAllKeysForSecClass(kSecClassIdentity);

        exit(0);
    }
}
