import { User } from "./user";

export interface IProfile {
  username: string;
  displayName: string;
  image?: string;
  bio?: string;
  //   followersCount: number;
  //   followingCount: number;
  //   following: boolean;
  // photos: Photo[];
}

export class Profile implements IProfile {
  constructor(user: User) {
    this.username = user.username;
    this.displayName = user.displayName;
    this.image = user.image;
    // this.bio = user.bio;
    // this.followersCount = user.followersCount;
    // this.followingCount = user.followingCount;
    // this.following = user.following;
  }

  username: string;
  displayName: string;
  image?: string;
  bio?: string;
  //   followersCount: number;
  //   followingCount: number;
  //   following: boolean;
}
